    public class GraphFFT {
        public void SetLine(String lineTitle, short[] values) {
          IPointListEdit ip = zgcGraph.GraphPane.CurveList[lineTitle].Points as IPointListEdit;
          int tmp = Math.Min(ip.Count, values.Length);
          int i = 0;
          peakX = values.Length;
    
          while(i < tmp) {
            if(values[i] > peakY) peakY = values[i];
            ip[i].X = i;
            ip[i].Y = values[i];
            i++;
          }
          while(ip.Count < values.Count) {
            if(values[i] > peakY) peakY = values[i];
            ip.Add(i, values[i]);
            i++;
          }
          while(values.Count > ip.Count) {
            ip.RemoveAt(ip.Count - 1);
          }
        }
      }
