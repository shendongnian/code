    string strHistoryTableOpeningTag = "[HistoryTable]";
    string strHistoryTableClosingTag = "[/HistoryTable]";
    int intStartPos = 0;
    int intEndPos = 0;
    if (blnWantToHide == True) {
	  //Remove history table
	  intStartPos = FinalOutPut.IndexOf(strHistoryTableOpeningTag);
	  intEndPos = FinalOutPut.IndexOf(strHistoryTableClosingTag) + strHistoryTableClosingTag.Length;
	 FinalOutPut = FinalOutPut.Remove(intStartPos, intEndPos - intStartPos);
    } else {
	  //Remove unwanted tags
	  FinalOutPut = FinalOutPut.Replace(strHistoryTableOpeningTag, "");
	  FinalOutPut = FinalOutPut.Replace(strHistoryTableClosingTag, "");
    }
