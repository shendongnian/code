    public class StringLabelProvider : NumericLabelProviderBase {
        private List<String> m_Labels;
        public List<String> Labels {
            get { return m_Labels; }
            set { m_Labels = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ToStringLabelProvider"/> class.
        /// </summary>
        public StringLabelProvider(List<String> labels) {                                                
            Labels = labels;                                    
        }
        public override UIElement[] CreateLabels(ITicksInfo<double> ticksInfo) {            
            
            var ticks = ticksInfo.Ticks;
            Init(ticks);            
            UIElement[] res = new UIElement[ticks.Length];
            LabelTickInfo<double> tickInfo = new LabelTickInfo<double> { Info = ticksInfo.Info };
            for (int i = 0; i < res.Length; i++) {
                tickInfo.Tick = ticks[i];
                tickInfo.Index = i;
                string labelText = "";
                
                labelText = Labels[Convert.ToInt32(tickInfo.Tick)];
               
                TextBlock label = (TextBlock)GetResourceFromPool();
                if (label == null) {
                    label = new TextBlock();
                }
                label.Text = labelText;
                res[i] = label;
                ApplyCustomView(tickInfo, label);
            }
            return res;
        }
    }
