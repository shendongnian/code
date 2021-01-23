    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Research.DynamicDataDisplay.Charts.Axes;
    using System.Globalization;
    namespace Microsoft.Research.DynamicDataDisplay.Charts {
    
    public class TradingLabelProvider : NumericLabelProviderBase {
        private List<DateTime> m_Labels;
        public List<DateTime> Labels {
            get { return m_Labels; }
            set { m_Labels = value; }
        }
        public TradingLabelProvider(DateTime start, List<DateTime> labels) {                                    
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
                
                if(Convert.ToInt32(tickInfo.Tick) <= Labels.Count && tickInfo.Tick >= 0) {
                    labelText = Labels[Convert.ToInt32(tickInfo.Tick)].ToString();
                }
                TextBlock label = (TextBlock)GetResourceFromPool();
                if (label == null) {
                    label = new TextBlock();
                }
                label.Text = labelText;
                label.ToolTip = ticks[i].ToString();
                res[i] = label;
                ApplyCustomView(tickInfo, label);
            }
            return res;
        }
    }
    }
