    foreach (var item in checkdocument)
    {
      HyperLink link = new HyperLink();
      link.ID = "file" + item.fileid;
      link.NavigateUrl = "~/files/attachment/result_document/" + item.resultdoc;
      HtmlGenericControl li = new HtmlGenericControl("li"); //Create html control <li>
      li.Controls.Add(link); //add hyperlink to <li>
      ulFiles.Controls.Add(li);  //add <li> to <ul>
    }    
