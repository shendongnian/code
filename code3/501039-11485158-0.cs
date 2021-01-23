     private void abc_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
            {
                abc.Margin = new Thickness(abc.Margin.Left +e.DeltaManipulation.Translation.X,
                    abc.Margin.Top + e.DeltaManipulation.Translation.Y,
                    abc.Margin.Right, abc.Margin.Bottom);
            }
