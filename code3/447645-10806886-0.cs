        public Skelet ToSkelet()
        {
            var result = new Skelet
            {
                Waiting = Waiting.DeepClone().ConvertAll(x => x.Id),
                Open = Open.DeepClone().ConvertAll(x => x.Id),
                Finished = Finished //this one is int
            };
            return result;
        }
