        public static void Merge(XElement left, XElement right)
		{
			foreach (XElement node in right.Elements())
			{
				int num = MergeXml.NodeWithSameNameAtSameHierarchyLevel(left, node);
				if (num == 0)
				{
					left.Add(node);
				}
				else
				{
					if (MergeXml.IsFirstIteration(left, right) && !node.HasElements)
					{
						left.Add(node);
					}
					else
					{
						if (num == 1)
						{
							MergeXml.CheckDescandants(left, node);
						}
						else
						{
							if (node.Descendants().Any<XElement>() && node.Descendants().First<XElement>().Name.LocalName.Equals(node.Name.LocalName))
							{
								MergeXml.CheckDescandants(left, node);
							}
							else
							{
								int num2 = node.ElementsBeforeSelf().Count((XElement x) => x.Name.LocalName.Equals(node.Name.LocalName));
								foreach (XElement current in node.Elements())
								{
									if (current.HasElements)
									{
										if (MergeXml.ItemNodeExistInLeftFile(left, node, num2) || MergeXml.ItemNodeDescandandsDontHaveAnyElements(current))
										{
											MergeXml.CheckDescandants(left, current, num2);
										}
										else
										{
											(
												from x in left.Elements()
												where x.Name.LocalName.Equals(node.Name.LocalName)
												select x).ElementAt(num2).Add(current);
										}
									}
									else
									{
										(
											from x in left.Elements()
											where x.Name.LocalName.Equals(node.Name.LocalName)
											select x).ElementAt(num2).Add(current);
									}
								}
							}
						}
					}
				}
			}
		}
		public static XDocument MergeXmlFiles(List<XDocument> docs)
		{
			MergeXml.Merge(docs[0].Root, docs[1].Root);
			MergeXml.Merge(docs[0].Root, docs[2].Root);
			return docs[0];
		}
		private static void CheckDescandants(XElement left, XElement node)
		{
			if (node.Descendants().Count((XElement x) => x.HasElements) > 0)
			{
				MergeXml.Merge(left.Element(node.Name.LocalName), node);
				return;
			}
			if (left.Element(node.Name.LocalName) != null)
			{
				if (node.HasElements)
				{
					left.Element(node.Name.LocalName).Add(node.Descendants());
					return;
				}
				left.Element(node.Name.LocalName).Add(node);
				return;
			}
			else
			{
				if (node.HasElements)
				{
					left.Add(node.Descendants());
					return;
				}
				left.Add(node);
				return;
			}
		}
		private static void CheckDescandants(XElement left, XElement node, int recursivCallIndex)
		{
			if (node.Descendants().Count((XElement x) => x.HasElements) > 0)
			{
				MergeXml.Merge(left.Elements().ElementAt(recursivCallIndex).Element(node.Name.LocalName), node);
				return;
			}
			IEnumerable<XElement> source = 
				from x in left.Elements().ElementAt(recursivCallIndex).Descendants()
				where x.Name == node.Name
				select x;
			if (source.Count<XElement>() > 0)
			{
				source.ElementAt(0).Add(node.Descendants());
				return;
			}
			left.Elements().ElementAt(recursivCallIndex).Add(node);
		}
		private static bool IsFirstIteration(XElement left, XElement right)
		{
			return left.Parent == null && right.Parent == null;
		}
		private static bool ItemNodeDescandandsDontHaveAnyElements(XElement item)
		{
			return item.Descendants().Count((XElement x) => x.HasElements) == 0;
		}
		private static bool ItemNodeExistInLeftFile(XElement left, XElement node, int positionNodeInXmlIndex)
		{
			return left.Elements().ElementAt(positionNodeInXmlIndex).Element(node.Name.LocalName) != null;
		}
		private static int NodeWithSameNameAtSameHierarchyLevel(XElement left, XElement node)
		{
			if (!left.Descendants().Any<XElement>())
			{
				return 0;
			}
			if (left.Descendants().Count((XElement x) => x.Name.LocalName.Equals(node.Name.LocalName)) == 0)
			{
				return 0;
			}
			return left.Descendants().Count((XElement x) => x.Name.LocalName.Equals(node.Name.LocalName) && DivideXml.HasSameParentName(x, node));
		}
