            int pos = 1;
            for (int i = 0; i < bdCleanList.Count(); i++)
            {
                if ((i + 1) % Int32.Parse(textBox7.Text) == 0)
                {
                    package.Workbook.Worksheets.Add("B" + j);
                    worksheet = package.Workbook.Worksheets[j];
                    worksheet.Name = "B" + j;
                    
                    j += 1;
                    pos = 1;
                }
                worksheet.Cells[pos, 1].Value = bdCleanList[i];
                pos++;
            }
