    for (int i = 0; i < heap.Count; i++)
    {
                    dp1[i] = new DataPoint[3];
                    dp1[i][0] = new DataPoint(0D, (Convert.ToDouble(heap[i].Processed_Stock) * 360) / HeapTotalStock);//Convert.ToDouble(heap[i].Total_Stock));
                    dp1[i][0].Label = heap[i].Processed_Stock;
                    innerSeries.Points.Add(dp1[i][0]);
                    dp1[i][1] = new DataPoint(0D, (Convert.ToDouble(heap[i].Sold_Stock) * 360) / HeapTotalStock);//Convert.ToDouble(heap[i].Total_Stock));
                    dp1[i][1].Label = heap[i].Sold_Stock;
                    innerSeries.Points.Add(dp1[i][1]);
                    dp1[i][2] = new DataPoint(0D, ((Convert.ToDouble(heap[i].Total_Stock) - Convert.ToDouble(heap[i].Processed_Stock) - Convert.ToDouble(heap[i].Sold_Stock)) * 360) / HeapTotalStock);//Convert.ToDouble(heap[i].Total_Stock));
                    dp1[i][2].Label = (Convert.ToDouble(heap[i].Total_Stock) - Convert.ToDouble(heap[i].Processed_Stock) - Convert.ToDouble(heap[i].Sold_Stock)).ToString();
                    innerSeries.Points.Add(dp1[i][2]);
    }
