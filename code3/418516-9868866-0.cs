    public Matrix<string> ApplyTemplate(object items)
        {
            ICollection<T> castedItems = new List<T>();
            // Cast items as a List<T>
            if (items is List<T>)
            {
                castedItems = (ICollection<T>)items;
            }
            else if (items is HashSet<T>)
            {
                castedItems = ((HashSet<T>)items).ToList();
            }
            // Generate rows
            foreach (T item in castedItems)
            {
                this.Rows.Add(new CSVExportTableRow<T>(item));
            }
            // Instantiate the matrix
            Matrix<string> matrix = new Matrix<string>();
            // Generate matrix for every row
            foreach (var row in this.Rows)
            {
                matrix = GenerateMatrix();
                // Generate matrix for every sub table
                foreach (var subTable in this.SubTables)
                {
                    matrix = matrix.AddMatrix(subTable.ApplyTemplate(this.Link.Compile().DynamicInvoke(row.Item)));
                }
            }
            return matrix;
        }
