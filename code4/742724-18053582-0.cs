    Query mainQuery = new Query();
            // you code here...
            if (purchasedBooks.Count > 0)
            {
                BooleanQuery filterPurchasedBooksQuery = new BooleanQuery();
                foreach (int bookId in purchasedBooks)
                {
                    filterPurchasedBooksQuery.Add(new TermQuery(new Term("BookId", bookId.ToString())), Occur.MUST_NOT);
                }
                Query.Add(filterPurchasedBooksQuery, Occur.MUST);
            }
            // do search
