    System.IO.StreamReader trainingStreamReader = new System.IO.StreamReader(trainingDataFile);
    SharpEntropy.ITrainingEventReader eventReader = new SharpEntropy.BasicEventReader(new SharpEntropy.PlainTextByLineDataReader(trainingStreamReader));
    SharpEntropy.GisTrainer trainer = new SharpEntropy.GisTrainer();
    trainer.TrainModel(eventReader);
    mModel = new SharpEntropy.GisModel(trainer);
