    Type myType = this.GetType();
    for(int i=0; i < checkList.Length; i++)
    {
        string fieldName = String.Format("checkBox{0}", i);
        FieldInfo info = myType.GetField(fieldName);
        CheckBox cb = (CheckBox)info.GetValue(this);
        if(checkList[i] == true)
        {
            cb.Checked = true;
            cb.CheckState = CheckState.Checked;
        }
    }
