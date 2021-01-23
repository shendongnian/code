    int main(int argc, char ** argv)
    {
    unsigned long long nFreq = GetPerformanceTicksInSecond();
    unsigned long long nBefore = GetPerformanceTicks();
    timer start1 = timer::start();
    
    CallSomeFunction();
    
    unsigned long long nAfter = GetPerformanceTicks();
    const unsigned long long nDiff = nAfter - nBefore;
    const unsigned long long nMicroseconds = GetTickMicroseconds(nDiff,nFreq);
    
    cout << "CallSomeFunction() took " << nMicroseconds << " " << time << endl;
    
    return 0;
    
    }
    
    unsigned long long GetPerformanceTicks()
    {
        LARGE_INTEGER nValue;
    
        ::QueryPerformanceCounter(&nValue);
    
        return nValue.QuadPart;
    }
    
    unsigned long long GetPerformanceTicksInSecond()
    {
        LARGE_INTEGER nFreq;
    
        ::QueryPerformanceFrequency(&nFreq);
    
        return nFreq.QuadPart;
    }
    
    double GetTickSeconds(unsigned long long nTicks,unsigned long long nFreq)
    {
        return static_cast<double>(nTicks) / static_cast<double>(nFreq);
    }
    
    unsigned long long GetTickMilliseconds(unsigned long long nTicks,unsigned long long nFreq)
    {
        unsigned long long nTicksInMillisecond = nFreq / 1000;
    
        return nTicks / nTicksInMillisecond;
    }
    
    unsigned long long GetTickMicroseconds(unsigned long long nTicks,unsigned long long nFreq)
    {
        unsigned long long nTicksInMicrosecond = nFreq / 1000000;
    
        return nTicks / nTicksInMicrosecond;
    }
