    class ParamList
    {
        public Dictionary<int,string> SubMenuBtnText = new Dictionary<int,string>();
        public Dictionary<int, string> SubMenuBtnImg = new Dictionary<int, string>();
        public Dictionary<int, string> SubMenuBtnBorder = new Dictionary<int, string>();
    }
    public ParamList CreateList(Type type)
    {
        FieldInfo[] fieldInfos = type.GetFields(
            BindingFlags.Public | BindingFlags.Static);
        ParamList p = new ParamList();
        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (fieldInfo.Name.Contains("SubMenuBtnText"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(14));
                p.SubMenuBtnText.Add(index, (string)fieldInfo.GetValue(null));
            }
            else if (fieldInfo.Name.Contains("SubMenuBtnImg"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(13));
                p.SubMenuBtnImg.Add(index, (string)fieldInfo.GetValue(null));
            }
            else if (fieldInfo.Name.Contains("SubMenuBtnBorder"))
            {
                int index = Convert.ToInt32(fieldInfo.Name.Substring(16));
                p.SubMenuBtnBorder.Add(index, (string)fieldInfo.GetValue(null));
            }
        }
        return p;
    }
    private void createButtons()
    {
        ParamList par = CreateList(typeof(AdvancedSubmenu));
        for (int i = 1; i < 5; i++)
        {
            SubBtnText[i].Text = par.SubMenuBtnText[i];
            pictureBoxSubBtn[i].Image = Image.FromFile(par.SubMenuBtnImg[i]);
            panelSubBtn[i].BorderStyle = par.SubMenuBtnBorder[i];
        }
    }
