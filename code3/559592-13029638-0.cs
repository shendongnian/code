    FieldInfo[] fieldInfos = typeof(AdvancedSubmenu).GetFields(
        BindingFlags.Public | BindingFlags.Static);
    Dictionary<string, string> values = new Dictionary<string, string>();
    foreach (FieldInfo fieldInfo in fieldInfos)
    {
        values.Add(fieldInfo.Name, (string)fieldInfo.GetValue(null));
    }
    SubBtnText[i].Text = values["SubMenuBtnText" + i];
    pictureBoxSubBtn[i].Image = Image.FromFile(values["SubMenuBtnImg" + i];);
    panelSubBtn[i].BorderStyle = values["SubMenuBtnBorder" + i];
