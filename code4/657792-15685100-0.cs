    [DataContract]
    public class CharacterClone
    {
        [DataMember] 
        public Point ImagePosition { get; set; }
        [DataMember] 
        public Char CharText { get; set; }
        [DataMember] 
        public double ImageDegree { get; set; }
        [DataMember] 
        public double ImageScale { get; set; }
        [DataMember] 
        public int ImageZOrder { get; set; }
        [DataMember] 
        public bool IsResizeCancel { get; set; }
        [DataMember] 
        public double MaxSliderValue { get; set; }
        [DataMember] 
        public double CurrentWidth { get; set; }
        [DataMember] 
        public double CurrentHeight { get; set; }
        
        public CharacterClone(Character original)
        { 
            ImagePosition = original.ImagePosition;
            CharText = original.CharText;
            ImageDegree = original.ImageDegree;
            ImageScale = original.ImageScale;
            ImageZOrder = original.ImageZOrder;
            IsResizeCancel = original.IsResizeCancel;
            MaxSliderValue = original.MaxSliderValue;
            CurrentWidth = original.CurrentWidth;
            CurrentHeight = original.CurrentHeight;
        }
    }
