    public class GroupByRowDrawFilter:IUIElementDrawFilter
    {
        public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            GroupByRowDescriptionUIElement element = (GroupByRowDescriptionUIElement)drawParams.Element;
            if (element.GroupByRow.Value is int)
            {
                int value = (int)element.GroupByRow.Value;
                if (value % 2 == 0)
                {
                    drawParams.AppearanceData.ForeColor = Color.Orange;
                }
            }
                
            return false;
        }
    
        public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            if (drawParams.Element is GroupByRowDescriptionUIElement)
                return DrawPhase.BeforeDrawElement;
            return DrawPhase.None;
        }
    }
