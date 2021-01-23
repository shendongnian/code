        class ColorAssigner
    {
        public Dictionary<string, ColorGroupDetails> ColorAssignments { get; private set; }
        public SortedList<double, Color> Colors { get; private set; }
        public ColorAssigner()
        {
            ColorAssignments = new Dictionary<string, ColorGroupDetails>();
            Colors = new SortedList<double, Color>()  { { 1, Color.Blue}, {2, Color.Red}, {3,Color.Green}, {4,Color.Yellow} };
        }
        public Color RequestColor(string groupName)
        {
            if (ColorAssignments.ContainsKey(groupName)) 
            {
                ColorAssignments[groupName].Count++;
                return ColorAssignments[groupName].AssignedColor;
            }
            var assignedColor = GetNextAvailableColor();
            ColorAssignments.Add(groupName, new ColorGroupDetails() { Count = 1, AssignedColor = assignedColor });
            return assignedColor;
        }
        private Color GetNextAvailableColor()
        {
            var assignedColors = ColorAssignments.Select(a => a.Value.AssignedColor).ToList();
            return Colors.Values.Except(assignedColors).First();
        }
        public void ReleaseColor(string groupName)
        {
            if (ColorAssignments.ContainsKey(groupName))
            {
                var count = ColorAssignments[groupName].Count -= 1;
                if (count < 1) ColorAssignments.Remove(groupName);
            }
        }
    }
        class ColorGroupDetails
        {
            public int Count { get; set; }
            public Color AssignedColor { get; set; }
        }
    }
