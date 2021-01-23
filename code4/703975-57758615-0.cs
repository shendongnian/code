public void SetOptions<TEnum>() where TEnum : Enum
{
    foreach (TEnum obj in Enum.GetValues(typeof(TEnum)))
    {
        var i = (int)(object)obj;
        if (i == 0) DefaultOption = new ListItem(obj.Description(), obj.ToString());
        DropDownList.Items.Add(new ListItem(obj.Description(), obj.ToString()));
    }
}
