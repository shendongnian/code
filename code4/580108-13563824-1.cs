     sbData.Append("<table>");
        int iColumnCounter = 0;
        sbData.Append("<tr>");
            
        for(int i = -4; i < lsiPeople.count; )
        {
        	iColumnCounter++;
        	i+=4;
        	if(5 == iColumnCounter)
        	{
        		iColumnCounter = 1;
        		i = i - 15;//we want the index to go back to start of next row
        		sbData.Append("</tr><tr>");
        	}
        	string sName = GetPersonName(i);
        	DropDownList_Student.Items.Add(new ListItem(sName, _iPerId.ToString()));
        	sbData.AppendFormat("<td><input class=\"studentCheckBox\" type=\"checkbox\" onClick=\"UpdateSelectedCounter()\" id={0} name=\"{1}\" value={0}>{1}</td>", _iPerId, sName);
        }
        
        sbData.Append("</tr>");
        sbData.Append("</table>");
