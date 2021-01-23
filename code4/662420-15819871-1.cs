    public void moveBooks(int quantityOfMovedBooks, int booksID)
    {
        int quantity = totalBooksInDB(booksID);
        if(quantity > quantityOfMovedBooks)
        {
            int finalQuantityOfBooks = quantity - quantityOfMovedBooks;
            queryString = "update Books set bQuantity=? where bID=?";
            using(OleDbConnection myComm = new OleDbCommand(queryString, myConn))
            {
                myComm.Parameters.AddWithValue("@p1", finalQuantityOfBooks);
                myComm.Parameters.AddWithValue("@p2", booksID);
                myConn.Open();
                myComm.ExecuteNonQuery();
            }
         }
         else
            MessageBox.Show("Invalid quantity to move");
    }
    public int totalBooksInDB(int bID)
    {
        int booksQuantity = 0;
        queryString = "select bQuantity from Books where bID=?";
        using(OleDbConnection myComm = new OleDbCommand(queryString, myConn))
        {
            myComm = new OleDbCommand(queryString, myConn);
            myComm.Parameters.AddWithValue("@p1", bID);
            myConn.Open();
            object result myComm.ExecuteScalar();
            if(result != null)
                booksQuantity = Convert.ToInt32(result);
        }
        return booksQuantity;
    }
