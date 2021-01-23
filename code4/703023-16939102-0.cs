         public void EditMember(Member member)
                {
                    string Name = member.Name;
                    string Surname = member.Surname;
                    string EntryDate = member.EntryDate.ToString("dd.MM.yyyy");
                    string Status = member.Status;
        
                  sqlConnection.Open();
                  sqlCommand = new SqlCommand("UPDATE Members SET Name=@Name, Surname=@Sirname,EntryDate=@EntryDate",sqlConnection);
                  sqlCommand.parameters.AddparameterWithValue("@Name",Name);
                  sqlCommand.parameters.AddparameterWithValue("@SirName",SirName);
                  sqlCommand.parameters.AddparameterWithValue("@EntryDate",EntryDate);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
