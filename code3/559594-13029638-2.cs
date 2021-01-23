    class ButtonParameters
    {
        public string SubMenuBtnText = string.Empty;
        public string SubMenuBtnImg = string.Empty;
        public string SubMenuBtnBorder = string.Empty;
    }
    public Dictionary<int, ButtonParameters> CreateParameters(Type type)
    {
        FieldInfo[] fieldInfos = type.GetFields(
            BindingFlags.Public | BindingFlags.Static);
        Dictionary<int, ButtonParameters> parameters = new Dictionary<int, ButtonParameters>();
        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (fieldInfo.Name.Contains("SubMenuBtnText"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(14));
                if (!parameters.ContainsKey(index))
                {
                    parameters.Add(index, new ButtonParameters());
                }
                parameters[index].SubMenuBtnText = (string)fieldInfo.GetValue(null);
            }
            else if (fieldInfo.Name.Contains("SubMenuBtnImg"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(13));
                if (!parameters.ContainsKey(index))
                {
                    parameters.Add(index, new ButtonParameters());
                }
                parameters[index].SubMenuBtnImg=  (string)fieldInfo.GetValue(null);
            }
            else if (fieldInfo.Name.Contains("SubMenuBtnBorder"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(16));
                if (!parameters.ContainsKey(index))
                {
                    parameters.Add(index, new ButtonParameters());
                }
                parameters[index].SubMenuBtnBorder= (string)fieldInfo.GetValue(null);
            }
        }
        return parameters;
    }
    private void createButtons()
    {
        Dictionary<int, ButtonParameters> buttons = CreateParameters(typeof(AdvancedSubmenu));
        for (int i = 1; i < 5; i++)
        {
            SubBtnText[i].Text = buttons[i].SubMenuBtnText;
            pictureBoxSubBtn[i].Image = Image.FromFile(buttons[i].SubMenuBtnImg);
            panelSubBtn[i].BorderStyle = buttons[i].SubMenuBtnBorder;
        }
    }
