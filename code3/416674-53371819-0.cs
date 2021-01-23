        public class submenuColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return ColorTranslator.FromHtml("#302E2D"); }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Silver; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return ColorTranslator.FromHtml("#21201F"); }
            }
            public override Color ToolStripContentPanelGradientBegin
            {
                get { return ColorTranslator.FromHtml("#21201F"); }
            }
        }
        public class LeftMenuColorTable : ProfessionalColorTable
        {
            public override Color MenuItemBorder
            {
                get { return ColorTranslator.FromHtml("#BAB9B9"); }
            }
            public override Color MenuBorder  //added for changing the menu border
            {
                get { return Color.Silver; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return ColorTranslator.FromHtml("#4C4A48"); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return ColorTranslator.FromHtml("#5F5D5B"); }
            }            
            public override Color ToolStripBorder
            {
                get { return ColorTranslator.FromHtml("#4C4A48"); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return ColorTranslator.FromHtml("#4C4A48"); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return ColorTranslator.FromHtml("#5F5D5B"); }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return ColorTranslator.FromHtml("#404040"); }
            }
            public override Color ToolStripGradientBegin
            {
                get { return ColorTranslator.FromHtml("#404040"); }
            }
            public override Color ToolStripGradientEnd
            {
                get { return ColorTranslator.FromHtml("#404040"); }
            }
            public override Color ToolStripGradientMiddle
            {
                get { return ColorTranslator.FromHtml("#404040"); }
            }
        }
