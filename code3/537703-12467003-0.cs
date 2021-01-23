        [PexPreparationMethod(typeof(Random))]
        public static void Prepare()
        {
            MRandom.Behavior = MoleBehaviors.Fallthrough;
            MRandom.AllInstances.NextInt32Int32 = (r, a, b) => { return 50; };
        }
