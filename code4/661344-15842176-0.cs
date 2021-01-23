    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("pca", PointPCA);
        info.AddValue("pps", PointProfiles);
        info.AddValue("am", AlignedMean);
        info.AddValue("transforms", Transforms);
        info.AddValue("fnames", FileNames);
    }
    public TrainingSet(SerializationInfo info, StreamingContext context)
    {
        PointPCA = info.GetValue("pca", typeof(PrincipalComponentAnalysis)) as PrincipalComponentAnalysis;
        Transforms = (List<Tuple<string, ITransform>>)info.GetValue("transforms", typeof(List<Tuple<string, ITransform>>));
        AlignedMean = info.GetValue("am", typeof(double[])) as double[];
        PointProfiles = (Dictionary<Tuple<int, int>, IPointTrainingSet>)info.GetValue("pps", typeof(Dictionary<Tuple<int, int>, IPointTrainingSet>));
        FileNames = info.GetValue("fnames", typeof(string[])) as string[];
    }
