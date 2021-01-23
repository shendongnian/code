    string code = string.Empty;
    var pageNumber = PageRepository.GetPageAsString(); // get page number
    code = string.Format("<script type=\"text/javascript\" src=\"mypage.asp?p={0}\"></script>", pageNumber);
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
    "stackoverflow", code, false);
