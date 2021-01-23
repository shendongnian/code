    if (bones.Count > SkinnedEffect.MaxBones)
    {
                    throw new InvalidContentException(string.Format(
                        "Skeleton has {0} bones, but the maximum supported is {1}.",
                        bones.Count, SkinnedEffect.MaxBones));
     }
