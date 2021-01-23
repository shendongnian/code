            var timeoutTime = 10;
			var tasksResult = await Task.WhenAll(
									listOfTasks.Select(x => Task.WhenAny(
										x, Task.Delay(TimeSpan.FromMinutes(timeoutTime)))
									)
								);
			
			
			var succeededtasksResponses = tasksResult
                                                   .OfType<Task<MyResult>>()
                                                   .Select(task => task.Result);
			
            if (succeededtasksResponses.Count() != listOfTasks.Count())
            {
                // Not all tasks were completed
				// Throw error or do whatever you want
            }
			
			//You can use the succeededtasksResponses that contains the list of successful responses
