    //Student Names
            for (int x = 0; x < cboStudent.Items.Count; x++)
                {
                    string fullName = cboStudent.Items[x] as string;
                    string firstName;
                    string lastName;
                    string[] parts = fullName.Split(new string[] { ", " }, StringSplitOptions.None);
                    if (parts.Length == 1)
                    {
                        parts = fullName.Split(' ');
                        if (parts.Length == 1)
                        {
                            lastName = fullName;
                            firstName = "";
                        }
                        else
                        {
                            lastName = parts[1];
                            firstName = parts[0];
                        }
                    }
                    else
                    {
                        lastName = parts[0];
                        firstName = parts[1];
                    }
                    excelApp.Cells[8 + x, 1] = firstName;
                    excelApp.Cells[8 + x, 2] = lastName;
                }
