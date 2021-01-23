    using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Resources;
	namespace AppResourceLib.Public.Reflection
	{
	  internal static class ResourceManagerCache
	  {
		private static Dictionary<Type, ResourceManager> _resourceManagerMap =
		  new Dictionary<Type, ResourceManager>();
		public static ResourceManager GetResourceManager(Type resourceType)
		{
		  ResourceManager resourceManager = null;
		  // Make sure the type is valid.
		  if (null != resourceType)
		  {
			// Try getting the cached resource manager.
			if (!ResourceManagerCache._resourceManagerMap.TryGetValue(resourceType, out resourceManager))
			{
			  // If it is not in the cache create it.
			  resourceManager = resourceType.InvokeMember(
				"ResourceManager",
				(BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic),
				null,                                                   
				null,                                                   
				null) as ResourceManager;
			  // If it was created, add the resource manager to the cache.
			  if (null != resourceManager)
			  {
				ResourceManagerCache._resourceManagerMap.Add(resourceType, resourceManager);
			  }
			}
		  }
		  return resourceManager;
		}
	  }
	}
