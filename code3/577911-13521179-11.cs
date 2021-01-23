        public static IEnumerable<IEnumerable<TListItem>> Split<TListItem>(this IEnumerable<TListItem> items, int parts)
            where TListItem : struct
        {
            var itemsArray = items.ToArray();
            int itemCount = itemsArray.Length;
            int itemsOnlastRow = itemCount - ((itemCount / parts) * parts);
            int numberOfRows = (int)(itemCount / (decimal)parts) + 1;
            for (int row = 0; row < numberOfRows; row++)
            {
                yield return SplitToRow(itemsArray, parts, itemsOnlastRow, numberOfRows, row);
            }
        }
        private static IEnumerable<TListItem> SplitToRow<TListItem>(TListItem[] items, int itemsOnFirstRows, int itemsOnlastRow,
                                                                    int numberOfRows, int row)
        {
            for (int column = 0; column < itemsOnFirstRows; column++)
            {
                // Are we on the last row?
                if (row == numberOfRows - 1)
                {
                    // Are we within the number of items on that row?
                    if (column < itemsOnlastRow)
                    {
                        yield return items[(column + 1) * numberOfRows -1];
                    }
                }
                else
                {
                    int firstblock = itemsOnlastRow * numberOfRows;
                    int index;
                    // are we in the first block?
                    if (column < itemsOnlastRow)
                    {
                        index = column*numberOfRows + ((row + 1)%numberOfRows) - 1;
                    }
                    else
                    {
                        index = firstblock + (column - itemsOnlastRow)*(numberOfRows - 1) + ((row + 1)%numberOfRows) - 1;
                    }
                    yield return
                        items[index];
                }
            }
        }
