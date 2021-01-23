        private Target FindTargetByName(string targetName)
        {
            if (LogManager.Configuration == null)
                return null;
            Target t = LogManager.Configuration.FindTargetByName(targetName);
            if (t is NLog.Targets.Wrappers.WrapperTargetBase)
            {
                var list = LogManager.Configuration.AllTargets.ToList();
                t = list.Find(x => x.Name == targetName + "_wrapped");
                return t;
            }
            else
            {
                return t;
            }
        }
		
