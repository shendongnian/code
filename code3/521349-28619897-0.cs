            Books[] bks = { new Books(1, "Shogun", "James Clavell"), new Books(2, "Pe aripile vantului", "Margaret Mitchell"), new Books(3, "MANDRIE SI PREJUDECATA", "Jane Austen"), new Books(4, "ANNA KARENINA", " Lev Tolstoi"), new Books(5, "Notre-Dame de Paris", "Victor Hugo"), new Books(6, "Marile speranțe", "Charles Dickens"), new Books(7, "Ion", "Liviu Rebreanu"), new Books(8, "Cărțile junglei", "Rudyard Kipling")};
            MySqlConnection con = new MySqlConnection("DataSource=localhost; UserID=root;database=" + nume);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Books (BookID, Title, ISBN, Number, NumberLeft) VALUES (@BookID, (@Title, (@ISBN, (@Number, (@NumberLeft)";
            MySqlTransaction tra = con.BeginTransaction();
            try
            {
                cmd.Transaction = tra;
                foreach (Books bo in bks)
                {
                    cmd.Parameters.AddWithValue("@BookID", bo.BookID);
                    cmd.Parameters.AddWithValue("@Title", bo.Title);
                    cmd.Parameters.AddWithValue("@ISBN", bo.ISBN);
                    cmd.Parameters.AddWithValue("@Number", bo.Number);
                    cmd.Parameters.AddWithValue("@NumberLeft", bo.NumberLeft);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tra.Commit();
                Console.WriteLine("Tabelul Books a fost umplut");
                con.Close();
            }
            catch (Exception ex)
            {
                tra.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
