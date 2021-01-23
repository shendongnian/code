       if (c.Name == "l") {
           e.Cancel = true;
           this.BeginInvoke(new Action(() => {
               toolTip1.IsBalloon = !toolTip1.IsBalloon;
               toolTip1.IsBalloon = !toolTip1.IsBalloon;
           }));
       }
