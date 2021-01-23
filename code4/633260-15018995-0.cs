     Style Style_Panel = new Style(typeof(Panel));
    
            public void Init_Style()
            {
                // Create Styles :
                #region "Create Styles"
    
                Style_Panel.Setters.Add(new Setter()
                {
                    Property = Panel.BackgroundProperty,
                    Value = new SolidColorBrush(Colors.Red)
                });
                Resources.Add(Style_Panel.TargetType, Style_Panel);
    
                #endregion
    
                // Apply Styles :
                #region "Apply Styles"
    
                List<Visual> List_Visual = new List<Visual>();
                List_Visual.Add(new StackPanel() { Name = "btn" });
                //Enum_Visual(Panel_Main, List_Visual);
                foreach (Visual visual in List_Visual)
                {
                    if (visual is Panel)
                    {
                        Panel panel = visual as Panel;
                        //if (Tagged(panel, "titlebar"))
                        //{
    
                        //}
                        //else if (Tagged(panel) == false)
                        {
                            // panel.Background = new SolidColorBrush( Colors.Red ); // <- WORKS .
                            panel.Style = Style_Panel; // <- DOES NOT WORKS !
                        }
                    }
                }
    
                #endregion
            }
