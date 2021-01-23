        /// <summary>
        /// Get the position and size of a displayed node.
        /// </summary>
        /// <param name="node">The node to get the bounds for.</param>
        /// <param name="cellIndex">The cell within the row to get the bounds for.  Defaults to 0.</param>
        /// <returns>Bounds if exists or empty rectangle if not.</returns>
        public Rectangle GetNodeBounds(NodeBase node, int cellIndex = 0)
        {
            // Check row reference
            RowInfo rowInfo = this.ViewInfo.RowsInfo[node];
            if (rowInfo != null)
            {
                // Get cell info from row based on the cell index parameter provided.
                CellInfo cellInfo = this.ViewInfo.RowsInfo[node].Cells[cellIndex] as CellInfo;
                if (cellInfo != null)
                {
                    // Return the bounds of the given cell.
                    return cellInfo.Bounds;
                }
            }
            return Rectangle.Empty;
        }
