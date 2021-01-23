    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Wordprocessing;
    using OpenXmlPowerTools;
    
    namespace MyNameSpace
    {
        class OpenXmlPowerToolsUtilities
        {
            public static XElement GetEffectiveRunProperties(WordprocessingDocument wordDoc, XElement run)
            {
                XElement runProperties = null;
                List<XElement> runPropertiesList = new List<XElement>();
    
                XElement paragraph = run.Parent;
                if (paragraph.Name != W.p)
                    return null;
    
                StyleDefinitionsPart styleDefinitionsPart = wordDoc.MainDocumentPart
                    .StyleDefinitionsPart;
                if (styleDefinitionsPart == null)
                    return null;
                XElement styles = styleDefinitionsPart.GetXDocument().Root;           
    
                // 1 - Get run default
                XElement runDefault = styles.Elements(W.docDefaults)
                    .Elements(W.rPrDefault)
                    .Elements(W.rPr)
                    .FirstOrDefault();
                if (runDefault != null)
                    runPropertiesList.Add(runDefault);
    
                // 2 - get paragraph style run properties
                XElement pStyleRunProperties = null;
                string pStyle = (string)paragraph.Elements(W.pPr)
                    .Elements(W.pStyle)
                    .Attributes(W.val)
                    .FirstOrDefault();
                if (pStyle != null)
                {
                    pStyleRunProperties = AssembleStyleInformation(styles, pStyle)
                                                           .Elements(W.rPr)
                                                           .FirstOrDefault();
                }
                else
                {
                    XElement defaultParagraphStyle = styles
                                            .Elements(W.style)
                                            .Where(e =>
                                                (string)e.Attribute(W.type) == "paragraph" &&
                                                   (string)e.Attribute(W._default) == "1")
                                            .Select(s => s)
                                            .FirstOrDefault();
                    pStyleRunProperties = defaultParagraphStyle.Elements(W.rPr).FirstOrDefault();
                }
                if (pStyleRunProperties != null)
                    runPropertiesList.Add(pStyleRunProperties);
    
                // 3 - get run style run properties
                string rStyle = (string)run.Elements(W.rPr).Elements(W.rStyle).Attributes(W.val).FirstOrDefault();
                XElement rStyleRunProperties = null;
                if (rStyle != null)
                {
                    rStyleRunProperties = AssembleStyleInformation(styles, rStyle)
                                                           .Elements(W.rPr)
                                                           .FirstOrDefault();
                }
                if (rStyleRunProperties != null)
                    runPropertiesList.Add(rStyleRunProperties);
    
                XElement toggleProperties = AssembleToggleProperties(runDefault, pStyleRunProperties, rStyleRunProperties);
                if (toggleProperties != null)
                    runPropertiesList.Add(toggleProperties);
    
                // 4 - direct run properties
                XElement directRunProperties = run.Elements(W.rPr).FirstOrDefault();
                if (directRunProperties != null)
                    runPropertiesList.Add(directRunProperties);
    
                runProperties = AssembleRunProperties(runPropertiesList);
    
                return runProperties;
            }
    
            private static XElement AssembleRunProperties(List<XElement> runPropertiesList)
            {
                return runPropertiesList
                    .Aggregate(
                        new XElement(W.rPr,
                        new XAttribute(XNamespace.Xmlns + "w", W.w)),
                        (mergedRun, run) =>
                            MergeChildElements(mergedRun, run));
            }
    
            static XElement AssembleToggleProperties(XElement runDefault, XElement pStyleRunProperties, XElement rStyleRunProperties)
            {
                XElement runToggleProperties;
    
                runToggleProperties = new XElement(W.rPr, 
                    new XAttribute(XNamespace.Xmlns + "w", W.w));
    
                foreach (XName toggleProperty in toggleProperties)
                {
                    XElement runDefaultToggleProperty = runDefault.Elements(toggleProperty).FirstOrDefault();
    
                    if (runDefaultToggleProperty != null)
                    {
                        if ((string)runDefaultToggleProperty.Attributes(W.val).FirstOrDefault() != "0")
                        {
                            runToggleProperties.Add(runDefaultToggleProperty);
                            continue;
                        }
                    }
    
                    XElement pStyleToggleProperty = null;
                    if (pStyleRunProperties == null)
                        pStyleToggleProperty = null;
                    else
                        pStyleToggleProperty = pStyleRunProperties.Elements(toggleProperty).FirstOrDefault();
                    
                    XElement rStyleToggleProperty = null;
                    if (rStyleRunProperties == null)
                        rStyleToggleProperty = null;
                    else
                        rStyleToggleProperty = rStyleRunProperties.Elements(toggleProperty).FirstOrDefault();
    
                    if (pStyleToggleProperty == null && rStyleToggleProperty != null)
                        runToggleProperties.Add(rStyleToggleProperty);
                    else if (pStyleToggleProperty != null && rStyleToggleProperty == null)
                        runToggleProperties.Add(pStyleToggleProperty);
                    else if (pStyleToggleProperty != null && rStyleToggleProperty != null)
                    {
                        if ((string)rStyleToggleProperty.Attributes(W.val).FirstOrDefault() == "0")
                            runToggleProperties.Add(pStyleToggleProperty);
                        else if ((string)pStyleToggleProperty.Attributes(W.val).FirstOrDefault() == "0")
                            runToggleProperties.Add(rStyleToggleProperty);
                        else
                            runToggleProperties.Add(new XElement(toggleProperty, new XAttribute(W.val, "0")));
                    }
                }
    
                return runToggleProperties;
            }
    
            public static IEnumerable<XElement> StyleChainReverseOrder(XElement styles, string styleId)
            {
                string current = styleId;
                while (true)
                {
                    XElement style = styles.Elements(W.style)
                        .Where(s => (string)s.Attribute(W.styleId) == current).FirstOrDefault();
                    yield return style;
                    current = (string)style.Elements(W.basedOn).Attributes(W.val).FirstOrDefault();
                    if (current == null)
                        yield break;
                }
            }
    
            public static IEnumerable<XElement> StyleChain(XElement styles, string styleId)
            {
                return StyleChainReverseOrder(styles, styleId).Reverse();
            }
    
            private static XElement AssembleStyleInformation(XElement styles, string styleId)
            {
                return StyleChain(styles, styleId)
                    .Aggregate(
                        new XElement(W.style, new XAttribute(XNamespace.Xmlns + "w", W.w)),
                        (mergedStyle, style) => MergeChildElements(mergedStyle, style));
            }
    
            public static XName[] Others =
            {
                W.pStyle,
                W.rStyle
            };
    
            public static XName[] ElementsWithMergeElementsSemantics =
            {
                W.style,
                W.rPr,
                W.pPr 
            };
    
            public static XName[] ElementsWithMergeAttributesSemantics =
            {
                W.ind,
                W.spacing,
                W.lang
            };
    
            public static XName[] ElementsWithReplaceElementsSemantics =
            {
                W.name, // The style Name element
                W.adjustRightInd,
                W.autoSpaceDE,
                W.autoSpaceDN,
                W.bidi,
                W.cnfStyle,  // within a table
                W.contextualSpacing,
                W.divId, 
                W.framePr,
                W.jc,
                W.keepLines,
                W.keepNext,
                W.kinsoku,
                W.mirrorIndents,
                W.numPr,
                W.outlineLvl,
                W.overflowPunct,
                W.pageBreakBefore,
                W.pBdr,  
                W.shd,
                W.snapToGrid,
                W.suppressAutoHyphens,
                W.suppressLineNumbers,
                W.suppressOverlap,
                W.tabs,  
                W.textAlignment,
                W.textboxTightWrap,  // within a textbox
                W.textDirection,
                W.topLinePunct,
                W.widowControl,
                W.wordWrap,
                W.b,
                W.bCs,
                W.bdr,
                W.caps,
                W.color,
                W.cs,
                W.dstrike,
                W.eastAsianLayout,
                W.effect,
                W.em,
                W.emboss,
                W.fitText,
                W.highlight,
                W.i,
                W.iCs,
                W.imprint,
                W.kern,
                W.noProof,
                W.oMath,
                W.outline,
                W.position,
                W.rFonts,
                W.rtl,
                W.shadow,
                W.shd,
                W.smallCaps,
                W.snapToGrid,
                //W.spacing,   // different from paragraph spacing
                W.specVanish,
                W.strike,
                W.sz,
                W.szCs,
                W.u,  
                W.vanish,
                W.vertAlign,
                W._w, 
                W.webHidden           
            };
    
            public static XName[] toggleProperties =
            {
                W.b,
                W.bCs,
                W.caps,
                W.emboss,
                W.i,
                W.iCs,
                W.imprint,
                W.outline,
                W.shadow,
                W.smallCaps,
                W.strike,
                W.vanish
            };
    
            public static bool IsValidMergeElement(XName name)
            {
                if (ElementsWithMergeAttributesSemantics.Contains(name) ||
                    ElementsWithMergeElementsSemantics.Contains(name) ||
                    ElementsWithReplaceElementsSemantics.Contains(name))
                    return true;
    
                return false;
            }
    
            public static bool IsToggleProperty(XName name)
            {
                if (toggleProperties.Contains(name))
                    return true;
    
                return false;
            }
    
            public static bool HasReplaceSemantics(XName name)
            {
                if (ElementsWithReplaceElementsSemantics.Contains(name))
                    return true;
    
                return false;
            }
    
            public static bool HasMergeElementsSemantics(XName name)
            {
                if (ElementsWithMergeElementsSemantics.Contains(name))
                    return true;
    
                return false;
            }
    
            public static bool HasMergeAttributesSemantics(XName name)
            {
                if (ElementsWithMergeAttributesSemantics.Contains(name))
                    return true;
    
                return false;
            }
            
            public static XElement MergeChildElements(XElement mergedElement, XElement element)
            {
                if (mergedElement == null || element == null)
                {
                    if (element == null)
                        element = mergedElement;
                    XElement newElement = new XElement(element.Name,
                        new XAttribute(XNamespace.Xmlns + "w", W.w),
                        element.Attributes()
                       .Where(a =>
                       {
                           if (a.IsNamespaceDeclaration)
                               return false;
                           if (element.Name == W.style)
                               if (!(a.Name == W.type || a.Name == W.styleId))
                                   return false;
                           return true;
                       }),
                    element.Elements().Select(e =>
                    {
                        if (e.Name == W.rPr || e.Name == W.pPr)
                            return MergeChildElements(null, e);
    
                        if (IsValidMergeElement(e.Name))
                            return e;
    
                        return null;
                    }));
                    return newElement;
                }
    
                XElement newMergedElement = new XElement(element.Name,
                    new XAttribute(XNamespace.Xmlns + "w", W.w),
                    element.Attributes()
                       .Where(a =>
                       {
                           if (a.IsNamespaceDeclaration)
                               return false;
                           if (element.Name == W.style)
                               if (!(a.Name == W.type || a.Name == W.styleId))
                                   return false;
                           return true;
                       }),
                    element.Elements().Select(e =>
                    {
                        if (HasReplaceSemantics(e.Name))
                            return e;
    
                        // spacing within run properties has replace semantics 
                        if (element.Name == W.rPr && e.Name == W.spacing)
                            return e;
    
                        if (HasMergeAttributesSemantics(e.Name))
                        {
                            XElement newElement;
                            newElement = new XElement(e.Name,
                                e.Attributes(),
                                mergedElement.Elements(e.Name).Attributes()
                                    .Where(a =>
                                        !(e.Attributes().Any(z => z.Name == a.Name))));
                            return newElement;
                        }
    
                        if (e.Name == W.rPr || e.Name == W.pPr)
                        {
                            XElement correspondingElement = mergedElement.Element(e.Name);
                            return MergeChildElements(correspondingElement, e);
                        }
                        return null;
                    }),
                    mergedElement.Elements()
                        .Where(m => !element.Elements(m.Name).Any()));
    
                return newMergedElement;
            }
        }
    }
    
    
     
