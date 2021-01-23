			const QueryDisplayFlags pathType = QueryDisplayFlags.OnlyActivePaths;
			// query active paths from the current computer.
			// note that 0 is equal to SUCCESS!
			// TODO; HARDCODE MAGIC VALUES AWAY.
			if (CCDWrapper.GetDisplayConfigBufferSizes(pathType, out numPathArrayElements,
													   out numModeInfoArrayElements) == 0)
			{
				var pathInfoArray = new DisplayConfigPathInfo[numPathArrayElements];
				var modeInfoArray = new DisplayConfigModeInfo[numModeInfoArrayElements];
				// TODO; FALLBACK MECHANISM THAT HANDLES DIFFERENT VALUES FOR ZERO.
				if (CCDWrapper.QueryDisplayConfig(
					pathType,
					ref numPathArrayElements, pathInfoArray,
					ref numModeInfoArrayElements,
					modeInfoArray, IntPtr.Zero) == 0)
				{
					pathInfoArray[0].targetInfo.rotation = DisplayConfigRotation.Rotate90;
					CCDWrapper.SetDisplayConfig((uint) numPathArrayElements, pathInfoArray, (uint) numModeInfoArrayElements,
					                            modeInfoArray, SdcFlags.Apply | SdcFlags.UseSuppliedDisplayConfig);
				}
             }
