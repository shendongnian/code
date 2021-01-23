        public static void AutosizeColumnsWithArray(DataGrid grid, PaintEventArgs e)
        {
            Font dataFont = grid.Font;
            Font headerFont = GetHeaderFont(dataFont);
            IList list = null;
            if (grid.DataSource is IList)
            {
                list = (IList) grid.DataSource;
            }
            else if (grid.DataSource is IListSource)
            {
                list = ((IListSource) grid.DataSource).GetList();
            }
            if (list == null || list.Count < 0)
            {
                return;
            }
            if (grid.TableStyles.Count == 0)
            {
                return;
            }
            var pdc = TypeDescriptor.GetProperties(list[0]);
            var dataGridTableStyle = new DataGridTableStyle();
            dataGridTableStyle.MappingName = GetMappingName(list);
            int totalWidth = 0;
            for (int i = 0; i < pdc.Count; i++)
            {
                var columnName = pdc[i].Name;
                bool validColumn = grid.TableStyles[0].GridColumnStyles.Contains(columnName);
                if (!validColumn)
                {
                    continue;
                }
                var gridColumnStyle = grid.TableStyles[0].GridColumnStyles[columnName];
                var indexToEdit = grid.TableStyles[0].GridColumnStyles.IndexOf(gridColumnStyle);
                var headerText = grid.TableStyles[0].GridColumnStyles[columnName].HeaderText;
                var maxSize = e.Graphics.MeasureString(headerText, headerFont);
                int maxLength = headerText.Length;
                int rowCount = 0;
                const int maxRowsToCompare = 200;
                foreach (object o in list)
                {
                    if (rowCount == maxRowsToCompare)
                    {
                        break;
                    }
                    object result = pdc[i].GetValue(o);
                    string value = result == null ? string.Empty : result.ToString().Trim();
                    if (ValueCannotBeLongest(value, maxLength))
                    {
                        rowCount++;
                        continue;
                    }
                    SizeF size = e.Graphics.MeasureString(value, dataFont);
                    if (size.Width > maxSize.Width)
                    {
                        maxSize = size;
                        maxLength = value.Length;
                    }
                    rowCount++;
                }
                var newWidth = (int) (maxSize.Width + 5);
                grid.TableStyles[0].GridColumnStyles[indexToEdit].Width = newWidth;
                totalWidth += newWidth;
            }
        }
        private static bool ValueCannotBeLongest(string value, int maxLength)
        {
            return (value.Length == 0) || (value.Length + 3 < maxLength);
        }
        private static string GetMappingName(IList list)
        {
            string result;
            if (list is ITypedList)
            {
                result = ((ITypedList) list).GetListName(null);
            }
            else
            {
                result = list.GetType().Name;
            }
            return result;
        }
        private static Font GetHeaderFont(Font dataFont)
        {
            string FontName = dataFont.Name;
            float FontSize = dataFont.Size;
            return new Font(FontName, FontSize, FontStyle.Bold);
        }
