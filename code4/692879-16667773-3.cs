    public int GetHashCode(SkillRequirement obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.Skill.GetHashCode();
            hash = hash * 23 + obj.Requirement.GetHashCode();
            return hash;
        }
    }
