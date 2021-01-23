        public bool IsExist(Guid id)
        {
            SpinWait.SpinUntil(() => repository.ContainsKey(id)); - you can add Timout
            return true;
        }
