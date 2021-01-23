           string sql = "Insert INTO Book Values (@BookId, @BookName, @ISBNNo, @PublicationId, @CategoryId, @Pages,@Price,@Author1,@Author2,@TotalCopies,@IssuedCopies,@AvailableCopies,@SupplierName,@Note)";
        
         DataRow dRow = bookDS.Tables["Book"].NewRow();
        
                       dRow[0] = Convert.ToInt64(textBookID.Text);
                       dRow[1] = textBookName.Text;
                       dRow[2] = textISBN.Text;
                       bookDS.Tables["Book"].Rows.Add(dRow);
    //This would help you to commit all the changes at once.   
     bookDS.AcceptChanges();
