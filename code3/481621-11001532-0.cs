        private List<Color> GetColorList1()
        {
            IVsUIShell uiShell = (IVsUIShell)this.GetService(typeof(IVsUIShell));
            List<Color> result = new List<Color>();
            foreach (VSSYSCOLOR vsSysColor in Enum.GetValues(typeof(VSSYSCOLOR)))
            {
                uint win32Color;
                uiShell.GetVSSysColor(vsSysColor, out win32Color);
                Color color = ColorTranslator.FromWin32((int)win32Color);
                result.Add(color);
            }
            return result;
        }
        private List<Color> GetColorList2()
        {
            IVsUIShell2 uiShell = (IVsUIShell2)this.GetService(typeof(IVsUIShell2));
            List<Color> result = new List<Color>();
            foreach (__VSSYSCOLOREX vsSysColor in Enum.GetValues(typeof(__VSSYSCOLOREX)))
            {
                uint win32Color;
                uiShell.GetVSSysColorEx((int)vsSysColor, out win32Color);
                Color color = ColorTranslator.FromWin32((int)win32Color);
                result.Add(color);
            }
            return result;
        }
