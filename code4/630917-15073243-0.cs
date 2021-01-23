    int nRecords = Doc.MailMerge.DataSource.RecordCount;
    for (int i = 1; i <= nRecords; i++)
    {
        Doc.MailMerge.DataSource.FirstRecord = i; //It doesn't work 
        Doc.MailMerge.DataSource.LastRecord = i; // it doesn't work
        Doc.MailMerge.DataSource.ActiveRecord = (i == 1 ?   
        Word.WdMailMergeActiveRecord.wdFirstDataSourceRecord :Word.WdMailMergeActiveRecord.wdNextDataSourceRecord);
        Doc.MailMerge.DataSource.ActiveRecord = (i == nRecords ? Word.WdMailMergeActiveRecord.wdLastDataSourceRecord : Doc.MailMerge.DataSource.ActiveRecord);
        dynamic fields = Doc.MailMerge.DataSource.DataFields;
    }
