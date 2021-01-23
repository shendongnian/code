            var tasks = GetTasks();
            var basedir = AppDomain.CurrentDomain.BaseDirectory; // Get AppDomain Path
            var tasksPath = Path.Combine(basedir, "Tasks"); // append 'Tasks' subdir
            // NOTE: Cannot be factored, relies on 'tasksPath' variable (above).
            AppDomain.CurrentDomain.AssemblyResolve += (s, e) => // defined 'AssemblyResolve' handler
            {
                var assemblyname = e.Name + ".dll"; // append DLL to assembly prefix
                // *expected* assembly path
                var assemblyPath = Path.Combine(tasksPath, assemblyname); // create full path to assembly
                if (File.Exists(assemblyPath)) return Assembly.LoadFile(assemblyPath); // Load Assembly as file.
                return null; // return Null if assembly was not found. (throws Exception)
            };
            foreach (var task in tasks.OrderBy(q => q.ExecutionOrder)) // enumerate Tasks by ExecutionOrder
            {
                Type importTaskType = Type.GetType(task.TaskType); // load task Type (may cause AssemblyResolve event to fire)
                if (importTaskType == null)
                {
                    log.Warning("Task Assembly not found");
                    continue;
                }
                ConstructorInfo ctorInfo = importTaskType.GetConstructor(Type.EmptyTypes); // get constructor info
                IImportTask taskInstance = (IImportTask)ctorInfo.Invoke(new object[0]); // invoke constructor and cast as IImportTask
                taskInstances.Add(taskInstance);
            }
            // rest of import logic omitted...
