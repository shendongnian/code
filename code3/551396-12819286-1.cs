    public class VoxelHolder
    {
        private readonly Voxel[] m_array;
        private readonly int m_index;
        public Voxel Value
        {
            get { return m_array[m_index]; }
        }
        public VoxelHolder(Voxel[] array, int index)
        {
            m_array = array;
            m_index = index;
        }
        public static explicit operator Voxel(VoxelHolder holder)
        {
            return holder.Value;
        }
    }
