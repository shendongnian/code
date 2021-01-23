		private static IEnumerable<Container> DoMerge(List<Container> elements, TimeSpan maxDiff)
		{
			var closedContainers = new List<Container>();
			var lastContainers = new Dictionary<int, Container>();
			foreach (Container container in elements.OrderBy(e => e.Start))
			{
				//First case, no previous container
				if (!lastContainers.ContainsKey(container.Id))
				{
					lastContainers[container.Id] = container;
				}
				else if (container.Start - lastContainers[container.Id].Stop > maxDiff)
					//We have a container, but not in our windows of 5 minutes
				{
					closedContainers.Add(lastContainers[container.Id]);
					lastContainers[container.Id] = container;
				}
				else
				{
					//We have to merge our two containers
					lastContainers[container.Id].Stop = container.Stop;
				}
			}
			//We have now to put all "lastContainer" in our final list
			foreach (KeyValuePair<int, Container> lastContainer in lastContainers)
			{
				closedContainers.Add(lastContainer.Value);
			}
			return closedContainers;
		}
