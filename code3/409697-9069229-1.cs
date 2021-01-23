    public interface IBone
    {
        int FirstValue { get; }
        int SecondValue { get; }
        BoneOrientation Orientation { get; set; }
        IBone left { get; set; }
        IBone right { get; set; }
        IBone upper { get; set; }
        IBone lower { get; set; }
    }
