    public abstract class ProductionLineGroupFormatter<T> where T : ProductionLine 
    { 
        public string Render(ProductionLineGroup<T> group) 
        { 
            foreach (T line in group.ProductionLines) 
            { 
                AppendProductionLine(line);
            } 
            return sb.ToString(); 
        }
        protected abstract void AppendProductionLine(T line);
    } 
    public class TissueProductionLineGroupFormatter : ProductionLineGroupFormatter<TissueProductionLine>
    { 
        protected override void AppendProductionLine(TissueProductionLine line)
        { 
            sb.Append(@"<tr> 
                            <td>" + line.Name + @"</td> 
                            <td>" + line.Actual + @"</td> 
                            <td>" + line.Target + @"</td> 
                            <td>" + line.Variance + @"</td> 
                            <td>" + line.PercentOnTarget + @"</td> 
                    </tr>"); 
        } 
    } 
