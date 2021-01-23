    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Your.NameSpace
    {
        [NLog.LayoutRenderers.LayoutRenderer("shorten")]
        [NLog.LayoutRenderers.AmbientProperty("HeadLength")]
        [NLog.LayoutRenderers.AmbientProperty("TailLength")]
        [NLog.LayoutRenderers.AmbientProperty("WarnMsg")]
        public class ShortenRendererWrapper : NLog.LayoutRenderers.Wrappers.WrapperLayoutRendererBase
        {
    
    
            [System.ComponentModel.DefaultValue(500)]
            public int HeadLength { get; set; }
    
            [System.ComponentModel.DefaultValue(500)]
            public int TailLength { get; set; }
    
            [System.ComponentModel.DefaultValue(true)]
            public bool ShowWarnMsg { get; set; }
    
            [System.ComponentModel.DefaultValue("###_SHORTENED_###")]
            public string WarnMsg { get; set; }
    
            public ShortenRendererWrapper()
            {
                HeadLength = 500;
                TailLength = 500;
                ShowWarnMsg = true;
                WarnMsg = "###_SHORTENED_###";
            }
            
            protected override string Transform(string text)
            {
                if (text.Length > (HeadLength + TailLength))
                {
                    if (HeadLength > 0 && TailLength > 0)
                        return text.Substring(0, HeadLength)
                            + (ShowWarnMsg ? "<........." + WarnMsg + ".........>" : string.Empty)
                            + text.Substring(text.Length - TailLength, TailLength);
                    else if (HeadLength > 0)
                        return text.Substring(0, HeadLength)
                            + (ShowWarnMsg ? "<........." + WarnMsg + ">" : string.Empty);
                    else if (TailLength > 0)
                        return (ShowWarnMsg ? "<" + WarnMsg + ".........>" : string.Empty)
                            + text.Substring(text.Length - TailLength, TailLength);
                    else
                        return text;
                }
                else
                    return text;
            }        
        }
    }
