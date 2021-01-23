    public override UIElement[] CreateLabels(ITicksInfo<double> ticksInfo) {            
            
            var ticks = ticksInfo.Ticks;
            Init(ticks);            
            UIElement[] res = new UIElement[ticks.Length];
            LabelTickInfo<double> tickInfo = new LabelTickInfo<double> { Info = ticksInfo.Info };
            for (int i = 0; i < res.Length; i++) {
                tickInfo.Tick = ticks[i];
                tickInfo.Index = i;
                string labelText = "";
                
                if(Convert.ToInt32(tickInfo.Tick) == 1) {
                    labelText = "High";
                } else if(Convert.ToInt32(tickInfo.Tick) == 0) {
					labelText = "Medium"
				} else if(Convert.ToInt32(tickInfo.Tick) == -1) {
					labelText = "Low"
				} else {
					labelText = ""
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
