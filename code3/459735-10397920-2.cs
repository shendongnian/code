    Controls.Add(new LiteralControl("<table>"));
    
    foreach(var singleStudent in students)
    {
        //Code to add other rows
        Button deleteButton = new Button();
        deleteButton.ID = "deleteStudentWithID" + singleStudent.ID.ToString();
        deleteButton.Text = "X";
            
        Controls.Add(new LiteralControl("<tr><td class=\"style5\">"));
        Controls.Add(deleteButton);
        Controls.Add(new LiteralControl("</td></tr>");
    }
    
    Controls.Add(new LiteralControl("</table>"));
