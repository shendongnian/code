    return (from a in IDs
            from b in a.Values
            where b.Code == code
            select (new A
            {
                ID = a.ID, Values = new List<B>
                {
                    new B
                    {
                        Code = b.Code, 
                        DisplayName = b.DisplayName
                    }
                }
            })).FirstOrDefault();
