    using DocumentFormat.OpenXml.Packaging;
    using System;
    using System.Linq;
    using DRAW = DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Presentation;
    .....
    using (PresentationDocument outputDocument = PresentationDocument.Open(@"C:\Users\YN\Desktop\80.pptx", true))
    {
        Slide slide = outputDocument.PresentationPart.SlideParts.First<SlidePart>().Slide;
        CommonSlideData csd = slide.GetFirstChild<CommonSlideData>();
        ShapeTree st = csd.GetFirstChild<ShapeTree>();
        Shape s = st.GetFirstChild<Shape>();
        ShapeProperties sp = s.GetFirstChild<ShapeProperties>();
        DRAW.SolidFill sf = sp.GetFirstChild<DRAW.SolidFill>();
        DRAW.SchemeColor sc = sf.GetFirstChild<DRAW.SchemeColor>();
        DRAW.Alpha a = sc.GetFirstChild<DRAW.Alpha>();
        Console.WriteLine((int)a.Val);
    }
