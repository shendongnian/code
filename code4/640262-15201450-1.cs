    public void Execute<TChunk>(var _performanceLogger, Func<TChunk> getChunks, Action<IContainer, container> doWork)
        {
            _performanceLogger.Log("Start");
    
            var chunks = getChunks();
    
            Parallel.ForEach(chunks, chunk =>
            {
                using (var container = ObjectFactory.Container.GetNestedContainer())
                {
                    using (var unitOfWork = new UnitOfWork())
                    {
                        doWork(container, chunk);
                        unitOfWork.Commit();
                    }
                }
            });
    
            _performanceLogger.Log("Done");
        }
    }
    
    
    Execute<IEnumerable<object>>(
        logger,
        () => GetChunksToWorkOn(),
        (container, chunk) => container.GetInstance<Worker>().DoWork(chunk));
