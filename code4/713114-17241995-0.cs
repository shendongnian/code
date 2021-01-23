        while (i < myTable.Rows.Count)
        {
            tRow = tblCropsAndFeed.Rows[i];
            string tInputBox0 = tRow.Cells[0].Controls[0].ClientID;
            tContent = (HtmlInputText)tRow.FindControl(tInputBox0);
            tNameNode.InnerText = tContent.Value;
            string tInputBox1 = tRow.Cells[1].Controls[0].ClientID;
            tContent = (HtmlInputText)tRow.FindControl(tInputBox1);
            tUnitsNode.InnerText = tContent.Value;
            string tInputBox2 = tRow.Cells[2].Controls[0].ClientID;
            tContent = (HtmlInputText)tRow.FindControl(tInputBox2);
            tValueNode.InnerText = tContent.Value;
            tNewEntryNode.AppendChild(tNameNode);
            tNewEntryNode.AppendChild(tUnitsNode);
            tNewEntryNode.AppendChild(tValueNode);
            tCropsAndFeedNode.AppendChild(tNewEntryNode);
            i++;
        }
