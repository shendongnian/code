    public class MyLabels
    {
        public Dictionary<string, Label> _labels =
                      new Dictionary<string< Label>();
        public MyLabels() {
            _labels.Add("TaskSequence", TaskSequenceLabel);
            _labels.Add("TaskStatus", TaskStatusLabel);
            // etc.
        }
        public Label Named(string name) {
            return _labels[name];
        }
    }
    // Usage:
    var labels = new MyLabels();
    attributeValues.ForEach(value => {
        string label = attributes.First(a => a.ID == value.AttributeID).Name;
        labels.Named(value.AttributeName) = label;
    });
