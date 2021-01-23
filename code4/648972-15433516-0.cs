            foreach (var condition in conditions.AsParallel()) {
                var tasksCondition = condition
                tasks.Add(Task.Factory.StartNew(() => {
                    if (tasksCondition(item)) {
                        filteredData.Remove(item);
                    }
                }));
