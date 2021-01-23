        m_Panorama.ManipulationStarted += m_Panorama_ManipulationStarted;
        
        void m_Panorama_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            m_Panorama.IsHitTestVisible = false;           
        }
