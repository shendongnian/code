            string s = GetData(users, row =>
            {
                row.cell = new string[3];
                row.cell[0] = item.ID.ToString();
                row.cell[1] = item.name;
                row.cell[2] = item.age.ToString();
            });
