    Button deleteButton = new Button();
    deleteButton.ID = "deleteStudentWithID" + singleStudent.ID.ToString();
    deleteButton.Text = "X";
    
    Controls.Add(new LiteralControl("<tr><td class=\"style5\">"));
    Controls.Add(deleteButton);
    Controls.Add(new LiteralControl("</td></tr>");
